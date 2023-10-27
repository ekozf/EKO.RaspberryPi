type ServerDetails = {
    version: string,
    os: string,
    framework: string,
    timestamp: Date,
    uptime: string
}

const updaterFunction = async () => {
    const response = await fetch('/api/version');

    const data: ServerDetails = await response.json();

    const timestamp = new Date(data.timestamp);
    const uptime = data.uptime;

    const timestampElement = document.querySelector('#timestamp-field');
    const uptimeElement = document.querySelector('#uptime-field');

    if (timestampElement) {
        timestampElement.textContent = DateFormatter(timestamp);
    }

    if (uptimeElement) {
        uptimeElement.textContent = UptimeFormatter(uptime);
    }
}

const updater = setInterval(updaterFunction, 5_000);

function DateFormatter(date: Date) {

    const day = FormatSmallerThanTen(date.getDate());

    const month = date.getMonth() + 1;

    const hours = FormatSmallerThanTen(date.getHours());

    const minutes = FormatSmallerThanTen(date.getMinutes());

    const seconds = FormatSmallerThanTen(date.getSeconds());


    return day + '/' + month + '/' + date.getFullYear() + ' ' + hours + ':' + minutes + ':' + seconds;
}

function UptimeFormatter(uptime: string) {
    const timespan = uptime.split(':');

    const hours = RemoveLeadingZero(timespan[0]);

    const minutes = RemoveLeadingZero(timespan[1]);

    let seconds = RemoveLeadingZero(timespan[2]);

    if (seconds.includes('.')) {
        seconds = seconds.split('.')[0];
    }

    return hours + 'h ' + minutes + 'm ' + seconds + 's';
}

function FormatSmallerThanTen(value: number) {
    if (value < 10) {
        return '0' + value;
    }

    return value.toString();
}

function RemoveLeadingZero(value: string) {
    if (value.startsWith('0')) {
        return value.substring(1);
    }

    return value;
}
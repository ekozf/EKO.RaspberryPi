type ServerDetails = {
    version: string;
    os: string;
    framework: string;
    timestamp: Date;
    uptime: string;
};
declare const updaterFunction: () => Promise<void>;
declare const updater: number;
declare function DateFormatter(date: Date): string;
declare function UptimeFormatter(uptime: string): string;
declare function FormatSmallerThanTen(value: number): string;
declare function RemoveLeadingZero(value: string): string;
//# sourceMappingURL=keepUpdated.d.ts.map
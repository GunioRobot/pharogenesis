openPreferenceWindow
	| morphicWindow mainPanel firstLine lastLine bugReportButton helpButton closeButton |
	morphicWindow _ SystemWindow labelled: 'AddressBook Preferences'.
	morphicWindow model: self.
	mainPanel _ AlignmentMorph newColumn.

	"Set-up of first line"
	firstLine _  AlignmentMorph newColumn.
	firstLine addMorphBack: ((StringMorph contents:'Sorry, no preferences for the meantime')  emphasis: 1 ).
	helpButton _ PluggableButtonMorph
				on: CelesteAddressBook
				getState: nil
				action: #openHelp. 

	helpButton  label: 'Help';
		 setBalloonText: 'Show a small usage help'.
	firstLine addMorphBack: helpButton.

	"Set-up of last line. Note: I change the resize layout for having a small button bar"
	lastLine _  AlignmentMorph newRow vResizing: #shrinkWrap.
	bugReportButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: #sendBugReportEmail.
	bugReportButton 
		 label: 'Send a Bug Report';
		 setBalloonText: 'Send a Bug report to Giovanni Giorgi about this tool';
		 onColor: Color white offColor: Color white.
	closeButton _ PluggableButtonMorph
				on: morphicWindow
				getState: nil
				action: #delete.
	closeButton  label: 'Close';  setBalloonText: 'Close This window'.
	"Arranging last line"
	lastLine addMorphBack: ((StringMorph contents:'Current Mantainer: Giovanni Giorgi')  emphasis: 1 ; color: Color blue).
	lastLine addMorphBack: bugReportButton; addMorphBack: closeButton.

	"Componing window:"
	mainPanel addMorphBack: firstLine; addMorphBack: lastLine.
	morphicWindow addMorph: mainPanel frame: (0@0 extent: 1@1).
	morphicWindow minimumExtent: 250@200; openInMVC; extent: 400@200.
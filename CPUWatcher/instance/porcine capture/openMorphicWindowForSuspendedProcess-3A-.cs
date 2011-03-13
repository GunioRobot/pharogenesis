openMorphicWindowForSuspendedProcess: aProcess
	| menu rules |
	menu := MenuMorph new.
	"nickname  allow-stop  allow-debug"
	rules := ProcessBrowser nameAndRulesFor: aProcess.
	menu add: 'Dismiss this menu' target: menu selector: #delete; addLine.
	menu add: 'Open Process Browser' target: ProcessBrowser selector: #open.
	menu add: 'Resume'
		target: self
		selector: #resumeProcess:fromMenu:
		argumentList: { aProcess . menu }.
	menu add: 'Terminate'
		target: self
		selector: #terminateProcess:fromMenu:
		argumentList: { aProcess . menu }.
	rules third ifTrue: [
		menu add: 'Debug at a lower priority'
			target: self
			selector: #debugProcess:fromMenu:
			argumentList: { aProcess . menu }.
	].
	menu addTitle: aProcess identityHash asString,
		' ', rules first,
		' is taking too much time and has been suspended.
What do you want to do with it?'.
	menu stayUp: true.
	menu popUpInWorld

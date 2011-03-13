openUpButton
	"Answer a button whose action would be to open up the receiver or snap it back closed"

	| aButton aForm |
	aButton := IconicButton new borderWidth: 0.
	aForm := ScriptingSystem formAtKey: #PowderBlueOpener.
	aForm ifNil:
		[aForm := Form extent: 13@22 depth: 16 fromArray: #( 0 0 12017 787558129 0 0 0 0 12017 787561309 995965789 787558129 0 0 0 787561309 995965789 995965789 995965789 787546112 0 12017 995965789 995965789 995965789 995965789 995962609 0 12017 995965789 995965789 995965789 995965789 995962609 0 787561309 995965789 995965789 995965789 995965789 995965789 787546112 787561309 995965789 995965789 995965789 995965789 995965789 787546112 787561309 995965789 995950593 80733 995965789 995965789 787546112 787561309 995965789 65537 65537 80733 995965789 787546112 787561309 995950593 80733 995950593 80733 995965789 787546112 787561309 995950593 80733 995950593 80733 995965789 787546112 787561309 995950593 65537 65537 80733 995965789 787546112 787561309 995965789 65537 65537 995965789 995965789 787546112 787561309 995965789 995965789 995965789 995965789 995965789 787546112 787561309 995965789 995965789 995965789 995965789 995965789 787546112 787561309 995965789 995965789 995965789 995965789 995965789 787546112 787561309 995965789 995965789 995965789 995965789 995965789 787546112 12017 995965789 995965789 995965789 995965789 995962609 0 12017 995965789 995965789 995965789 995965789 995962609 0 0 787561309 995965789 995965789 995965789 787546112 0 0 12017 787561309 995965789 787558129 0 0 0 0 12017 787558129 0 0 0) offset: 0@0.
		ScriptingSystem saveForm: aForm atKey: #PowderBlueOpener].
	aButton labelGraphic: aForm.
	aButton
		target: self;
		color: Color transparent;
		actionSelector: #toggleWhetherShowingOnlyTopControls;
		setBalloonText: 'open or close the lower portion that shows individual scripts' translated.
	^ aButton
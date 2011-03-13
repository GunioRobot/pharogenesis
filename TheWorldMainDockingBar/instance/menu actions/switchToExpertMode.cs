switchToExpertMode
	| ok |
	ok := self confirm: 'CAUTION!
The expert mode is powerful as well as dangerous and you can break your Squeak in several ways.
Are you sure to switch to expert mode?' translated.
	ok
		ifFalse: [^ self].
	""
	Preferences enable: #cmdGesturesEnabled.
	Preferences enable: #debugHaloHandle.
	Preferences disable: #noviceMode.

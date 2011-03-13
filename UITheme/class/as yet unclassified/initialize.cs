initialize
	"Set up ui enhancement preferences here."

	Preferences
		addPreference: #showTextEditingState
		categories: #(morphic)
		default: false
		balloonHelp: 'When enabled the editing state of PluggableTextMorphs is shown as a colored inset border.' translated;
		addPreference: #externalFocusForPluggableText
		categories: #(morphic)
		default: true
		balloonHelp: 'When enabled the focus indication for PluggableTextMorphs will be drawn in the border rather than around the embedded TextMorph.' translated;
		addPreference: #mouseClickForKeyboardFocus
		categories: #(morphic)
		default: false
		balloonHelp: 'When enabled the mouse button must be clicked within a morph for it to take the keyboard focus.' translated;
		addPreference: #gradientScrollbarLook
		categories: #(scrolling windows)
		default: true
		balloonHelp: 'Scrollbars have a nicer appearance using UITheme.' translated;
		addPreference: #gradientButtonLook
		categories: #(buttons windows)
		default: true
		balloonHelp: 'Buttons have a nicer appearance using UITheme.'  translated;
		addPreference: #windowsActiveOnFirstClick
		categories: #(windows)
		default: false
		balloonHelp: 'When disabled, the first click of an inactive window will only activate it rather than also controlling a submorph.' translated;
		addPreference: #fadedBackgroundWindows
		categories: #(windows)
		default: true
		balloonHelp: 'Background windows appear more "washed out" to distinguish from the active window.' translated;
		addPreference: #windowAnimation
		categories: #(windows)
		default: true
		balloonHelp: 'Animate the minimising, restoring, expanding and (optionally) closing of windows.' translated;
		addPreference: #noWindowAnimationForClosing
		categories: #(windows)
		default: false
		balloonHelp: 'Don''t animate the closing of windows.' translated;
		addNumericPreference: #windowAnimationDelay
		categories:  #(windows)
		default: 10
		balloonHelp: 'The delay between each step of the window animation in milliseconds.' translated;
		addNumericPreference: #windowAnimationSteps
		categories:  #(windows)
		default: 15
		balloonHelp: 'The number of steps in the window animation.'  translated.
	self current class = UITheme ifTrue: [self current: nil] "due to change to being abstract".
	Smalltalk addToStartUpList: self
initialize
	"Initialize the receiver."
	
	Preferences
		addPreference: #showWorldTaskbar
		categories: #(#'docking bars' windows)
		default: true
		balloonHelp: 'Whether the world''s taskbar should be shown or not.'
		projectLocal: false
		changeInformee: self
		changeSelector: #showTaskbarPreferenceChanged;
		addPreference: #worldTaskbarWindowPreview
		categories: #(#'docking bars' windows)
		default: true
		balloonHelp: 'Whether the world''s taskbar buttons should show previews of the associated window while the mouse is over them.'.
	self showTaskbarPreferenceChanged
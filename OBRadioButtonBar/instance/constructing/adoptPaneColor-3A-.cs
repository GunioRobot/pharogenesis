adoptPaneColor: aColor
	self submorphs do: [:ea | ea onColor: aColor darker offColor: aColor lighter]
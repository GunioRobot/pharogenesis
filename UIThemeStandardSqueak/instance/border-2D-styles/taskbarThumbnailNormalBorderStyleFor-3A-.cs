taskbarThumbnailNormalBorderStyleFor: aWindow
	"Return the normal thumbnail borderStyle for the given button."

	^BorderStyle simple
		width: 1;
		baseColor: Preferences menuBorderColor
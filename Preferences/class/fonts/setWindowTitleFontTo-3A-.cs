setWindowTitleFontTo: aFont

	Parameters at: #windowTitleFont put: aFont.
	StandardSystemView setLabelStyle.
	Utilities replaceToolsFlap
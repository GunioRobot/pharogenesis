windowColorHelp
	"The 'Window Colors' panel lets you select colors for the standard Squeak windows.

The three buttons entitled 'Bright', 'Pastel', and 'White' let you install three different standard color schemes.

The rows of color swatches and tool names indicate what the color for each tool is currently set to be.  You can change the color for any tool by clicking on its swatch, then choosing a new color in the ensuing color-picker.

'TranscriptStream' governs the color of Transcripts.
'MessageSet' governs the color of message-list browsers.
'ChangeList' governs the color of change-list browsers *and* versions browsers.
'StringHolder' governs the color of Workspaces.

Any time you request a new window (browser, file-list, etc.), the current window-color setting for that kind of window will determine what color is used.

But note that if in Morphic, the 'Tools' flap and the 'Standard Parts Bin' both contain pre-allocated window prototypes, and these will not automatically change when you edit the standard window colors.  To get the Tools flap to reflect your latest color choices, hit the 'Update Tools Flap' button.  To get the standard parts bin to reflect your latest color choices, evaluate 'ScriptingSystem resetStandardPartsBin'"

	(StringHolder new contents: (self class firstCommentAt: #windowColorHelp))
		openLabel: 'About Window Colors'

	"Preferences windowColorHelp"
copy: charForm toClipBoardAs: char ascent: ascent
	ParagraphEditor new clipboardTextPut:
		(Text string: char asString
			attribute: (TextFontReference toFont: 
				(FormSetFont new
					fromFormArray: (Array with: charForm)
					asciiStart: char asciiValue
					ascent: ascent)))
"
	The S in the Squeak welcome window was installed by doing the following
	in a workspace (where the value of, eg, charForm will persist through BitEdit...
	f _ TextStyle default fontAt: 4.
	oldS _ f characterFormAt: $S.
	charForm _ Form extent: oldS extent depth: 8.
	oldS displayOn: charForm.
	charForm bitEdit.
	...Play around with the BitEditor, then accept and close...
	FormSetFont copy: charForm toClipBoardAs: $S ascent: f ascent.
	...Then do a paste into the Welcome window
"
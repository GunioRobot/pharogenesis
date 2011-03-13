changeDefaultFontSizeBy: delta      "TextStyle changeDefaultFontSizeBy: 1"
	"This sample method recreates the default textStyle, with font 1 being a size
	larger than the smallest.  It then initializes most references in the system
	as well, although most windows will have to beclosed and reopened to get the effect."
	| allFonts |
	allFonts _ TextStyle default fontArray asSortedCollection: [:a :b | a height < b height].
	TextConstants at: #DefaultTextStyle put:
		(TextStyle fontArray: ((1 to: allFonts size) collect: [:i | allFonts atWrap: i+delta])).
	"rbb 2/18/2005 13:18 - How should this work for UIManager?"
	PopUpMenu initialize.  "Change this method for difft menu font"
	ListParagraph initialize.  "Change this method for difft ListPane font"
	StandardSystemView initialize.  "Change this method for difft Window label font"

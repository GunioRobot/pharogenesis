setDefaultFonts: defaultFontsSpec
	"Since this is called from menus, we can take the opportunity to prompt for missing font styles."

	| fontNames map emphases |
	fontNames _ defaultFontsSpec collect: [:array | array second].
	map _ IdentityDictionary new.
	emphases _ IdentityDictionary new.
	fontNames do: [:originalName | | decoded style response |
		decoded := TextStyle decodeStyleName: originalName.
		style _ map at: originalName put: (TextStyle named: decoded second).
		emphases at: originalName put: decoded first.
		style ifNil: [
			response _ TextStyle modalStyleSelectorWithTitle: 'Choose replacement for text style ', originalName.
			map at: originalName put: (response ifNil: [TextStyle default])]].

	defaultFontsSpec do: [:triplet | self
		perform: triplet first
		with: (((map at: triplet second) fontOfPointSize: triplet third) emphasis: (emphases at: triplet second))]
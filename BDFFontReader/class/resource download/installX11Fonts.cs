installX11Fonts "BDFFontReader installX11Fonts"
	"Installs previously-converted .sf2 fonts into the TextConstants dictionary.  This makes them available as TextStyles everywhere in the image."

	| families fontArray textStyle |
	families _ #( 'Courier' 'Helvetica' 'LucidaBright' 'Lucida' 'LucidaTypewriter' 'NewCenturySchoolbook' 'TimesRoman' ).

	families do: [:family |
		fontArray _ StrikeFont readStrikeFont2Family: family.
		textStyle _ TextStyle fontArray: fontArray.
		TextConstants at: family asSymbol put: textStyle.
	].

defaultFontFamilies
	"Answer the set of available fonts families that are supported as Text objects
	in the font that they represent. Only includes FreeTypeFont/TTCFont."
	
	^(((TextStyle actualTextStyles
		select: [:ts | ts defaultFont isTTCFont])
		collect: [:ts | ts defaultFont familyName]) asSet
		collect: [:fam | |famTs|
			famTs := TextStyle named: fam.
			self isFreeTypeInstalled ifTrue: [ 
				(famTs defaultFont isSymbolFont or: [
						(famTs defaultFont hasDistinctGlyphsForAll: fam) not])
					ifTrue: [famTs := TextStyle default]].
			fam asText
				addAttribute: (TextFontReference
					toFont: (famTs fontOfPointSize: self theme listFont pointSize))])
			asSortedCollection: [:a :b | a asString <= b asString]
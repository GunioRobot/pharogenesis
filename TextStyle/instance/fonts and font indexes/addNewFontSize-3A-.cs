addNewFontSize: pointSize
	"Add a font in specified size to the array of fonts."
	| f d newArray t isSet |
	fontArray first emphasis ~= 0 ifTrue: [
		t _ TextConstants at: self fontArray first familyName asSymbol.
		t fonts first emphasis = 0 ifTrue: [
			^ t addNewFontSize: pointSize.
		].
	].

	pointSize <= 0 ifTrue: [^ nil].
	fontArray do: [:s |
		s pointSize = pointSize ifTrue: [^ s].
	].

	(isSet _ fontArray first isKindOf: TTCFontSet) 
	ifTrue:[
		| fonts |
		fonts _ fontArray first fontArray collect: [ :font |
			| newFont |
			(font isNil)
			ifTrue: [newFont _ nil]
			ifFalse: [
				newFont _ (font ttcDescription size > 256)
					ifTrue: [MultiTTCFont new initialize]
					ifFalse: [TTCFont new initialize].
				newFont ttcDescription: font ttcDescription.
				newFont pixelSize: pointSize * 96 // 72.
				font derivativeFonts notEmpty ifTrue: [font derivativeFonts do: [ :proto |
					proto ifNotNil: [
						d _ proto class new initialize.
						d ttcDescription: proto ttcDescription.
						d pixelSize: newFont pixelSize.
						newFont derivativeFont: d]]].
				].
			newFont].
		f _ TTCFontSet newFontArray: fonts]
	ifFalse: [
		f _ TTCFont new initialize.
		f ttcDescription: fontArray first ttcDescription.
		f pointSize: pointSize.
		fontArray first derivativeFonts do: [:proto |
			proto ifNotNil: [
				d _ TTCFont new initialize.
				d ttcDescription: proto ttcDescription.
				d pointSize: f pointSize.
				f derivativeFont: d.
			].
		].
	].
	newArray _ ((fontArray copyWith: f) asSortedCollection: [:a :b | a pointSize <= b pointSize]) asArray.
	self newFontArray: newArray.
	isSet ifTrue: [
		TTCFontSet register: newArray at: newArray first familyName asSymbol.
	].
	^ self fontOfPointSize: pointSize
reorganizeForNewFontArray: array name: styleName

	| style existings regular altName |
	(TextConstants includesKey: styleName) ifFalse: [
		TextConstants at: styleName put: (TextStyle fontArray: array).
		^ TextConstants at: styleName.
	].
 
	"There is a text style with the name I want to use.  See if it is a TTC font..."
	style _ TextConstants at: styleName.
	style isTTCStyle ifFalse: [
		altName _ ((array at: 1) name, 'TT') asSymbol.
		^ self reorganizeForNewFontArray: array name: altName.
	].

	existings _ (self getExistings: style fontArray), (Array with: array).
	regular _ existings detect: [:e | (e at: 1) isRegular] ifNone: [existings at: 1].

	regular do: [:r |
		r addLined: r.
	].

	"The existing array may be different in size than the new one."
	existings do: [:e |
		(e at: 1) isRegular ifFalse: [
			regular do: [ :r | | f |
				f _ e detect: [ :ea | ea pointSize = r pointSize ] ifNone: [ ].
				f ifNotNil: [ r derivativeFont: f ].
			].
		].
	].

	style newFontArray: regular.
	self register: regular at: styleName.
	self recreateCache.	
	^ style.

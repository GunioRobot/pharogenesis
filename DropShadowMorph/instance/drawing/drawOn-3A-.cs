drawOn: aCanvas
	"Draw my submorphs as a shadow, then fullDrawOn will droaw them normally."
	| shadowCanvas |
	submorphs isEmpty ifTrue: [^ super drawOn: aCanvas].

	shadowCanvas _ aCanvas copyForShadowDrawingOffset: shadowOffset.
	shadowCanvas stipple: color.
	submorphs reverseDo: [:m | m fullDrawOn: shadowCanvas].  "draw back-to-front"

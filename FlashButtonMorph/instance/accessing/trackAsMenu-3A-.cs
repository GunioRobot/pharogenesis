trackAsMenu: aBoolean
	"Currently unused"
	aBoolean 
		ifTrue:[self setProperty: #trackAsMenu toValue: true]
		ifFalse:[self removeProperty: #trackAsMenu].
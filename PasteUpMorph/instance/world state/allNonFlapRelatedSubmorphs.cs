allNonFlapRelatedSubmorphs
	"Answer all non-window submorphs that are not flap-related"
	^ submorphs select:
		[:m | (m isKindOf: SystemWindow) not and: [m isFlapOrTab not]]
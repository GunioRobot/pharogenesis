handlesMouseDown: evt
	"| localPt |

	localPt _ (self transformFrom: self world) globalPointToLocal: evt cursorPoint.
	submorphs do: [ :each | (each fullBounds containsPoint: localPt) ifTrue: [^false]]."
	^ true

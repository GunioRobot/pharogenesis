centerLabel
	"Align the center of the label with the center of the receiver's window."

	| alignPt |
	label ifNotNil: [
		alignPt _ label boundingBox center.
		(label isKindOf: Paragraph) ifTrue: [
			alignPt _ alignPt + (0@1)].  "compensate for leading in default style"
		label align: alignPt with: self getWindow center].

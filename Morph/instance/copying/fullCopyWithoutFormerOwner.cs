fullCopyWithoutFormerOwner
	"Like fullCopy, but does not copy over the former owner, which could bring a huge amount of extraneous baggage with it."

	| dict new anOwner |
	anOwner _ self formerOwner.
	self removeProperty: #formerOwner.
	dict _ IdentityDictionary new: 1000.
	new _ self copyRecordingIn: dict.
	new allMorphsDo: [:m | m updateReferencesUsing: dict].
	anOwner ifNotNil: [self formerOwner: anOwner].
	^ new
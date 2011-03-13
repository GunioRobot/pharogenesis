veryDeepInner: deepCopier
	| list values vv |
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  This is special code for the dictionary.  See DeepCopier."

	super veryDeepInner: deepCopier.
	locked _ locked veryDeepCopyWith: deepCopier.
 	visible _ visible veryDeepCopyWith: deepCopier.
 	sticky _ sticky veryDeepCopyWith: deepCopier.
 	balloonText _ balloonText veryDeepCopyWith: deepCopier.
 	balloonTextSelector _ balloonTextSelector veryDeepCopyWith: deepCopier.
 	externalName _ externalName veryDeepCopyWith: deepCopier.
 	isPartsDonor _ isPartsDonor veryDeepCopyWith: deepCopier.
 	actorState _ actorState veryDeepCopyWith: deepCopier.
 	player _ player veryDeepCopyWith: deepCopier.	"Do copy the player of this morph"
 	eventHandler _ eventHandler veryDeepCopyWith: deepCopier.	"has its own restrictions"

	otherProperties ifNotNil: [
		otherProperties _ otherProperties copy.
		list _ self copyWeakly.	"Properties whose values are only copied weakly"
		values _ list collect: [:pp | 
			vv _ otherProperties at: pp ifAbsent: [nil].
			vv ifNotNil: [otherProperties at: pp put: nil]. "zap it"
			vv].
	 	otherProperties _ otherProperties veryDeepCopyWith: deepCopier.
		1 to: list size do: [:ii | "put old values back"
			(values at: ii) ifNotNil: [otherProperties at: (list at: ii) put: (values at: ii)]]].

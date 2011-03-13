morphToDropFrom: aMorph
	"Given a morph being carried by the hand, which the hand is about to drop, answer the actual morph to be deposited.  Normally this would be just the morph itself, but several unusual cases arise, which this method is designed to service."

	| aNail representee handy posBlock tempPos |
	handy _ self primaryHand.
	posBlock _ [:z | 
			tempPos _ handy position - (handy targetOffset - aMorph formerPosition * (z extent / aMorph extent)) rounded.
			self pointFromWorld: tempPos].
	self alwaysShowThumbnail
		ifTrue: [aNail _ aMorph
						representativeNoTallerThan: self maxHeightToAvoidThumbnailing
						norWiderThan: self maximumThumbnailWidth
						thumbnailHeight: self heightForThumbnails.
			aNail == aMorph
				ifFalse: [aNail
						position: (posBlock value: aNail)].
			^ aNail].
	((aMorph isKindOf: MorphThumbnail)
			and: [(representee _ aMorph morphRepresented) owner == nil])
		ifTrue: [representee
				position: (posBlock value: representee).
			^ representee].

	self showingListView ifTrue:
		[^ aMorph listViewLineForFieldList: (self valueOfProperty: #fieldListSelectors)].

	(aMorph hasProperty: #newPermanentScript)
		ifTrue: [^ aMorph asEmptyPermanentScriptor].
	self automaticPhraseExpansion
		ifFalse: [^ aMorph].
	((aMorph isKindOf: PhraseTileMorph) or: [aMorph isKindOf: SyntaxMorph])
		ifFalse: [^ aMorph].
	^ aMorph morphToDropInPasteUp: self
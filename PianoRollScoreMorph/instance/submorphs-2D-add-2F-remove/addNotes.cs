addNotes

	| visibleMorphs rightEdge topEdge track trackColor i done n nLeft nTop nRight evt m |
	visibleMorphs _ OrderedCollection new: 500.
	rightEdge _ self right - borderWidth.
	topEdge _ self top + borderWidth + 1.

	"Add ambient morphs first (they will be front-most)"
	(track _ score ambientTrack) ifNotNil:
		[i _ indexInTrack at: indexInTrack size.
		done _ i > track size.
		[done | (i > track size)] whileFalse: [
			evt _ track at: i.
			nLeft _ self xForTime: evt time.
			nLeft > rightEdge
				ifTrue: [done _ true]
				ifFalse: [m _ evt morph.
						m position: nLeft @ (self bottom - borderWidth - m height).
						visibleMorphs add: evt morph].
			i _ i + 1]].

	"Then add note morphs"
	1 to: score tracks size do:
		[:trackIndex |
		track _ score tracks at: trackIndex.
		trackColor _ colorForTrack at: trackIndex.
		i _ indexInTrack at: trackIndex.
		done _ i > track size or: [scorePlayer mutedForTrack: trackIndex].
		[done | (i > track size)] whileFalse: [
			n _ track at: i.
			(n isNoteEvent and: [n midiKey >= lowestNote]) ifTrue: [
				nLeft _ self xForTime: n time.
				nLeft > rightEdge
					ifTrue: [done _ true]
					ifFalse: [
						nTop _ (self yForMidiKey: n midiKey) - 1.
						nTop > topEdge ifTrue: [
							nRight _ nLeft + (n duration * timeScale) truncated - 1.
							visibleMorphs add:
								((PianoRollNoteMorph
									newBounds: (nLeft@nTop corner: nRight@(nTop + 3))
									color: trackColor)
									trackIndex: trackIndex indexInTrack: i)]]].
			i _ i + 1].
			(selection notNil
				and: [trackIndex = selection first
				and: [i >= selection second and: [(indexInTrack at: trackIndex) <= selection third]]])
				ifTrue: [visibleMorphs do:
						[:vm | (vm isKindOf: PianoRollNoteMorph) ifTrue: [vm selectFrom: selection]]

].
			].

	"Add the cursor morph in front of all notes."
	cursor ifNil: [  "create the cursor if needed; this is for legacy PianoRollScoreMorphs..."
		cursor _
			Morph newBounds: (self topLeft extent: 1@1)  "height and position are set later"
			color: Color red].
	visibleMorphs addFirst: cursor.

	self changed.
	self removeAllMorphs.
	self addAllMorphs: visibleMorphs.

uncollapseSketch

	| uncollapsedVersion w whomToDelete |

	(w _ self world) ifNil: [^self].
	uncollapsedVersion _ self valueOfProperty: #uncollapsedMorph.
	uncollapsedVersion ifNil: [^self].
	whomToDelete _ self valueOfProperty: #collapsedMorphCarrier.
	uncollapsedVersion setProperty: #collapsedPosition toValue: whomToDelete position.

	whomToDelete delete.
	w addMorphFront: uncollapsedVersion.


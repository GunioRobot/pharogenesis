fixLayout

	| extraPerMorph fractionalExtra fractionAccumulator nextPlace extra space |
	extraPerMorph _ self extraSpacePerMorph asFloat.
	fractionalExtra _ extraPerMorph fractionPart.
	extraPerMorph _ extraPerMorph truncated.
	orientation = #horizontal
		ifTrue: [nextPlace _ bounds left + inset + borderWidth]
		ifFalse: [nextPlace _ bounds top + inset + borderWidth].

	fractionAccumulator _ 0.0.
	submorphs do: [:m |
		fractionAccumulator _ fractionAccumulator + fractionalExtra.
		fractionAccumulator > 0.5
			ifTrue: [
				extra _ extraPerMorph + 1.
				fractionAccumulator _ fractionAccumulator - 1.0]
			ifFalse: [extra _ extraPerMorph].
		space _ self placeAndSize: m at: nextPlace padding: extra.
		nextPlace _ nextPlace + space].

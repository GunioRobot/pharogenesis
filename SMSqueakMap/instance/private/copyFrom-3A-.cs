copyFrom: aMap
	"Copy all relevant info from the other map."

	objects _ aMap objects.
	objects do: [:o | o map: self].
	accounts _ users _ packages _ categories _ nil.
	checkpointNumber _ aMap checkpointNumber.
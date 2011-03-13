copyFrom: aMap
	"Copy all relevant info from the other map."

	objects := aMap objects.
	objects do: [:o | o map: self].
	accounts := users := packages := categories := nil.
	checkpointNumber := aMap checkpointNumber
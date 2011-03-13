testEvaporatePrim
	"This test should result in reducing each element of the array to 75% of its initial value."
	"StarSqueakMorph new testEvaporatePrim"

	| data |
	data := Bitmap new: 10.
	1 to: data size do: [:i | data at: i put: (10000 * i)].
	self primEvaporate: data rate: (75 * 1024) // 100.
	^ data asArray


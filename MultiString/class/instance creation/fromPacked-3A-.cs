fromPacked: aLong
	"Convert from a longinteger to a String of length 4."

	| s val |
	s _ self new: 1.
	val _ ((aLong digitAt: 4) << 24) |
			((aLong digitAt: 3) << 16) |
			((aLong digitAt: 2) << 8) |
			(aLong digitAt: 1).
	s basicAt: 1 put: val.
	^ s.

"MultiString fromPacked: 'TEXT' asPacked"

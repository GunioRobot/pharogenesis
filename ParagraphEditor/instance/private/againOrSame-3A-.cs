againOrSame: useOldKeys
	"Subroutine of search: and again.  If useOldKeys, use same FindText and ChangeText as before.
	 1/26/96 sw: real worked moved to againOrSame:many:"

	^ self againOrSame: useOldKeys many: Sensor leftShiftDown
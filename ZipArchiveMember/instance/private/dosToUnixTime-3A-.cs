dosToUnixTime: dt
	"DOS years start at 1980, Unix at 1970, and Smalltalk at 1901.
	So the Smalltalk seconds will be high by 69 years when used as Unix time_t values.
	So shift 1980 back to 1911..."
	| year mon mday hour min sec date time |

	year _ (( dt bitShift: -25 ) bitAnd: 16r7F ) + 1911.
	mon _ (( dt bitShift: -21 ) bitAnd: 16r0F ).
	mday _ (( dt bitShift: -16 ) bitAnd: 16r1F ).
	date _ Date newDay: mday month: mon year: year.

	hour _ (( dt bitShift: -11 ) bitAnd: 16r1F ).
	min _ (( dt bitShift: -5 ) bitAnd: 16r3F ).
	sec _ (( dt bitShift: 1 ) bitAnd: 16r3E ).
	time _ ((( hour * 60 ) + min ) * 60 ) + sec.

	^date asSeconds + time

	
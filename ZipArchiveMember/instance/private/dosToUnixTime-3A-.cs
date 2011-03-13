dosToUnixTime: dt
	"DOS years start at 1980, Unix at 1970, and Smalltalk at 1901.
	So the Smalltalk seconds will be high by 69 years when used as Unix time:=t values.
	So shift 1980 back to 1911..."
	| year mon mday hour min sec date time |

	year := (( dt bitShift: -25 ) bitAnd: 16r7F ) + 1911.
	mon := (( dt bitShift: -21 ) bitAnd: 16r0F ).
	mday := (( dt bitShift: -16 ) bitAnd: 16r1F ).
	date := Date newDay: mday month: mon year: year.

	hour := (( dt bitShift: -11 ) bitAnd: 16r1F ).
	min := (( dt bitShift: -5 ) bitAnd: 16r3F ).
	sec := (( dt bitShift: 1 ) bitAnd: 16r3E ).
	time := ((( hour * 60 ) + min ) * 60 ) + sec.

	^date asSeconds + time

	
testFromString
	"read SE file from string
		PNMReadWriter testFromString
	"
	| prw f s |
	prw _ self new.
	s _ 
'P1
#origin 1 0
3 1
1	01'.
	prw stream: (ReadStream on: s from: 1 to: (s size)).
	f _ prw nextImage.
	f morphEdit.
	Transcript cr;show:'Origin=', prw origin asString; cr.
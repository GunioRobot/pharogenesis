initializeClassificationTable
	"
	Initialize the classification table. The classification table is a
	compact encoding of upper and lower cases of characters with

		- bits 0-7: The lower case value of this character.
		- bits 8-15: The upper case value of this character.
		- bit 16: lowercase bit (e.g., isLowercase == true)
		- bit 17: uppercase bit (e.g., isUppercase == true)

	"
	| ch1 ch2 |

	LowercaseBit := 1 bitShift: 16.
	UppercaseBit := 1 bitShift: 17.

	"Initialize the letter bits (e.g., isLetter == true)"
	LetterBits := LowercaseBit bitOr: UppercaseBit.

	ClassificationTable := Array new: 256.
	"Initialize the defaults (neither lower nor upper case)"
	0 to: 255 do:[:i|
		ClassificationTable at: i+1 put: (i bitShift: 8) + i.
	].

	"Initialize character pairs (upper-lower case)"
	#(
		"Basic roman"
		($A $a) 	($B $b) 	($C $c) 	($D $d) 
		($E $e) 	($F $f) 	($G $g) 	($H $h) 
		($I $i) 		($J $j) 		($K $k) 	($L $l) 
		($M $m)	($N $n)	($O $o)	($P $p) 
		($Q $q) 	($R $r) 	($S $s) 	($T $t) 
		($U $u)	($V $v)	($W $w)	($X $x)
		($Y $y)	($Z $z)
		"International"
		($Ä $ä)	($Å $å)	($Ç $ç)	($É $é)
		($Ñ $ñ)	($Ö $ö)	($Ü $ü)	($À $à)
		($Ã $ã)	($Õ $õ)	($ $)	($Æ $æ)
		"International - Spanish"
		($Á $á)	($Í $í)		($Ó $ó)	($Ú $ú)
		"International - PLEASE CHECK"
		($È $è)	($Ì $ì)		($Ò $ò)	($Ù $ù)
		($Ë $ë)	($Ï $ï)
		($Â $â)	($Ê $ê)	($Î $î)	($Ô $ô)	($Û $û)
	) do:[:pair|
		ch1 := pair first asciiValue.
		ch2 := pair last asciiValue.
		ClassificationTable at: ch1+1 put: (ch1 bitShift: 8) + ch2 + UppercaseBit.
		ClassificationTable at: ch2+1 put: (ch1 bitShift: 8) + ch2 + LowercaseBit.
	].

	"Initialize a few others for which we only have lower case versions."
	#($ß $Ø $ø $ÿ) do:[:char|
		ch1 := char asciiValue.
		ClassificationTable at: ch1+1 put: (ch1 bitShift: 8) + ch1 + LowercaseBit.
	].

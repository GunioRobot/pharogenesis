rangesForJapanese
	| basics etc |
	basics := {  (Array  with: 0 with: 255)  }.
	etc := { 
		(Array 
			with: 880
			with: 1023).	"greek"
		(Array 
			with: 1024
			with: 1327).	"cyrillic"
		(Array 
			with: 7424
			with: 7551).	"phonetic"
		(Array 
			with: 7680
			with: 7935).	"latin extended additional"
		(Array 
			with: 8192
			with: 8303).	"general punctuation"
		(Array 
			with: 8352
			with: 8399).	"currency symbols"
		(Array 
			with: 8448
			with: 8527).	"letterlike"
		(Array 
			with: 8528
			with: 8591).	"number form"
		(Array 
			with: 8592
			with: 8703).	"arrows"
		(Array 
			with: 8704
			with: 8959).	"math operators"
		(Array 
			with: 8960
			with: 9215).	"misc tech"
		(Array 
			with: 9312
			with: 9471).	"enclosed alnum"
		(Array 
			with: 9472
			with: 9599).	"box drawing"
		(Array 
			with: 9600
			with: 9631).	"box elem"
		(Array 
			with: 9632
			with: 9727).	"geometric shapes"
		(Array 
			with: 9728
			with: 9983).	"misc symbols"
		(Array 
			with: 9984
			with: 10175).	"dingbats"
		(Array 
			with: 10176
			with: 10223).	"misc math A"
		(Array 
			with: 10224
			with: 10239).	"supplimental arrow A"
		(Array 
			with: 10496
			with: 10623).	"supplimental arrow B"
		(Array 
			with: 10624
			with: 10751).	"misc math B"
		(Array 
			with: 10752
			with: 11007).	"supplimental math op"
		(Array 
			with: 10496
			with: 10623).	"supplimental arrow B"
		(Array 
			with: 11904
			with: 12031).	"cjk radicals suppliment"
		(Array 
			with: 12032
			with: 12255).	"kangxi radicals"
		(Array 
			with: 12288
			with: 12351).	"cjk symbols"
		(Array 
			with: 12352
			with: 12447).	"hiragana"
		(Array 
			with: 12448
			with: 12543).	"katakana"
		(Array 
			with: 12688
			with: 12703).	"kanbun"
		(Array 
			with: 12784
			with: 12799).	"katakana extension"
		(Array 
			with: 12800
			with: 13055).	"enclosed CJK"
		(Array 
			with: 13056
			with: 13311).	"CJK compatibility"
		(Array 
			with: 13312
			with: 19903).	"CJK unified extension A"
		(Array 
			with: 19968
			with: 40879).	"CJK ideograph"
		(Array 
			with: 63744
			with: 64255).	"CJK compatiblity ideograph"
		(Array 
			with: 65072
			with: 65103).	"CJK compatiblity forms"
		(Array 
			with: 65280
			with: 65519)	"half and full"
	 }.
	^ basics , etc
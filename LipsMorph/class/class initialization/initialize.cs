initialize
	"
	LipsMorph initialize
	"
	| o u a e i m n p t s |
	a := {22@2. 39@4. 45@16. 23@23. 2@15. 9@4}.
	e := {23@2. 41@3. 45@15. 21@19. 2@14. 6@3}.
	i := {21@2. 40@4. 45@14. 23@16. 2@13. 8@4}.
	o := {18@1. 31@5. 31@20. 16@24. 3@19. 5@5}.
	u := {14@1. 23@6. 22@16. 11@20. 2@14. 3@4}.
	m := {17@2. 31@2. 27@4. 15@3. 2@4. 6@2}.
	n := {20@3. 33@2. 39@8. 19@9. 2@8. 7@2}.
	p := {7@1. 16@3. 12@5. 6@6. 1@4}.
	t := {14@2. 29@3. 21@7. 12@8. 1@3}.
	s := {19@2. 32@4. 35@10. 18@13. 2@10. 9@3}.
	PhoneticArticulations := Dictionary new.
	"Default"
	PhonemeSet arpabet do: [ :each | PhoneticArticulations at: each put: p].
	"Vowels"
	PhonemeSet arpabet do: [ :each |
		each name first = $a ifTrue: [PhoneticArticulations at: each put: a].
		each name first = $e ifTrue: [PhoneticArticulations at: each put: e].
		each name first = $i ifTrue: [PhoneticArticulations at: each put: i].
		each name first = $o ifTrue: [PhoneticArticulations at: each put: o].
		each name first = $u ifTrue: [PhoneticArticulations at: each put: u].
		each name first = $w ifTrue: [PhoneticArticulations at: each put: u]].
	"Particulars"
	PhoneticArticulations
		at: (PhonemeSet arpabet at: 'm') put: m;
		at: (PhonemeSet arpabet at: 'n') put: n;
		at: (PhonemeSet arpabet at: 't') put: t;
		at: (PhonemeSet arpabet at: 's') put: s;
		at: (PhonemeSet arpabet at: 'sh') put: s;
		at: (PhonemeSet arpabet at: 'sh') put: s;
		at: (PhonemeSet arpabet at: 'zh') put: s;
		at: (PhonemeSet arpabet at: 'th') put: s;
		at: (PhonemeSet arpabet at: 'jh') put: s;
		at: (PhonemeSet arpabet at: 'dh') put: s;
		at: (PhonemeSet arpabet at: 'd') put: s;
		at: (PhonemeSet arpabet at: 'z') put: s
packageSpecs
	
	"self new packageSpecs collect: [:arr |
		(SMSqueakMap default packageWithId: arr first)
releaseWithAutomaticVersionString: arr second]
	(SMSqueakMap default packageWithName: 'Shout') id 
     "
	
	^{
		{"Monticello"
'66236497-7026-45f5-bcf6-ad00ba7a8a4e'. '17'}.
		"shout" 
		{  '46dcf6af-067d-43e3-9fc9-d7010e067153' . ''}.

"rbEngine" 
		{  'a6930213-b578-49b1-862e-228cc5ab39e7' . '3.9.6'}.

"newCompiler" "ob"
		{"PointerExplorer missing class comments" 
			'1508934b-79ea-4216-956c-1948e9d48aad' . '1'} .
		{"VMMaker" 
'2e7f103e-22a6-470d-affe-54b1d04ef34a'. '3'}.
		{"Vassili's Regex"
'c32158f2-ab2c-49c4-8451-d920dcf1023c'. '1'}
	}
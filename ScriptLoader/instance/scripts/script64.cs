script64
	
	"See updateFrom7030"
	
| names | 
names := 'Kernel-al.126.mcz
Traits-al.220.mcz
FlexibleVocabularies-al.5.mcz
Monticello-al.296.mcz
System-al.85.mcz'  
findTokens: ' ', String cr.

	self loadOneAfterTheOther: names merge: false.

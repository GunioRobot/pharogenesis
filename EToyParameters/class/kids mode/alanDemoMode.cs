alanDemoMode
	"EToyParameters alanDemoMode"
	"If true, make everything behave exactly the way Alan wishes for his demos"
	
	AlanDemoMode ifNil: [AlanDemoMode _ true].
	^ AlanDemoMode
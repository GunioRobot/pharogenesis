initialize
	"Initialize the receiver, which was just created via a call to the  
	class's #basicNew"
	super initialize.
	""
	pageSize _ self defaultPageSize.
	self removeEverything.
	
	tabsMorph _ IndexTabs new.
	self addMorph: tabsMorph
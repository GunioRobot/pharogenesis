initialExtent
	"Make the full debugger longer!"

	dependents size < 9 ifTrue: [^ super initialExtent].	"Pre debug window"
	RealEstateAgent standardWindowExtent y < 400 "a tiny screen" 
		ifTrue: [^ super initialExtent].
	
	^ 600@700

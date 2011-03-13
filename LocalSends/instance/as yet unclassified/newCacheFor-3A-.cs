newCacheFor: aClass 
	"Creates an instance of SendCaches, assigns it to the instance variable sendCaches and fills it with all the self-sends class-sends and super-sends that occur in methods defined in this class (or by used traits)."

	| localSendCache info |
	localSendCache := SendCaches new.
	aClass selectorsAndMethodsDo: 
			[:sender :m | 
			info := (SendInfo on: m) collectSends.
			info selfSentSelectors 
				do: [:sentSelector | localSendCache addSelfSender: sender of: sentSelector].
			info superSentSelectors 
				do: [:sentSelector | localSendCache addSuperSender: sender of: sentSelector].
			info classSentSelectors 
				do: [:sentSelector | localSendCache addClassSender: sender of: sentSelector]].
	^localSendCache
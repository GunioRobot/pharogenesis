daylightSavingsInEffectAtStandardHour: hour
	"Return true if DST is observed at this very hour (standard time)"
	"Note: this *should* be the kernel method, and daylightSavingsInEffect
		should simply be self daylightSavingsInEffectAtHour: 3"

	self deprecated: 'Deprecated'.

	self daylightSavingsInEffect
		ifTrue: [^ (self addDays: -1) daylightSavingsInEffect or: [hour >= 2]]
		ifFalse: [^ (self addDays: -1) daylightSavingsInEffect and: [hour < 1]]
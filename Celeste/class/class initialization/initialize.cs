initialize
	"Celeste initialize"

	"user preferences"
	CCList _ nil.
	DeleteInboxAfterFetching _ false.
	PopServer _ nil.
	PopUserName _ nil.
	SmtpServer _ nil.
	SuppressWorthlessHeaderFields _ true.
	UserName _ nil.

	"options with no UI; just set their values directly"
	FormatWhenFetching _ false.

	"dictionary of custom filters"
	CustomFilters _ Dictionary new.

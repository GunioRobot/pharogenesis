saveNewLog
	"Create a new logfile and store the model condensed in it.
	A slave SqueakMap can do this at any time, it is done automatically at least
	once every 6 months. A master SqueakMap should not do this often at all -
	the more seldom it does the longer backlog it has and can feed slaves with incremental
	updates instead of forcing them to a complete download.
	First chunk is current date. Categories are saved first (top down),
	then all the cards followed by the repositories.
	At the end we tack on the last known transactionId."

	| file |
	self createNewLog.
	[ file _ self openLogFile setToEnd.
	self storeOn: file.
	firstTransactionNumber _ transactionCounter]
		ensure: [file close]
sendMailTo: recipient regardingPackageRelease: pr
	"Send mail to the given recipient. Try to use the first of:
	- MailSender (with its registered composition class)
	- Celeste
	- AdHocComposition
	for compatibility with 3.5 and 3.6 images"

	self sendMail: (String streamContents: [:stream |
		stream
			nextPutAll: 'From: '; nextPutAll: self mailUserName; cr;
			nextPutAll: 'To: '; nextPutAll: recipient; cr;
			nextPutAll: 'Subject: Regarding '; nextPutAll: pr printName; cr])
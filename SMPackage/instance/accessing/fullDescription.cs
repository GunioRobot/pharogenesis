fullDescription
	"Return a full textual description of the package. 
	Most of the description is taken from the last release."
	| s publishedRelease |
	s := TextStream on: (Text new: 400).

	self
		describe: name
		withBoldLabel: 'Name:		'
		on: s.

	summary isEmptyOrNil
		ifFalse: [self
				describe: summary
				withBoldLabel: 'Summary:	'
				on: s ].

	author isEmptyOrNil
		ifFalse: [s
				withAttribute: TextEmphasis bold
				do: [s nextPutAll: 'Author:'];
				 tab;
				 tab.
			s
				withAttribute: (PluggableTextAttribute
						evalBlock: [self userInterface
										sendMailTo: (SMUtilities stripEmailFrom: author)
										regardingPackageRelease: self lastRelease])
				do: [s nextPutAll: author];
				 cr].
	self owner
		ifNotNil: [s
				withAttribute: TextEmphasis bold
				do: [s nextPutAll: 'Owner:'];
				 tab; tab.
			s
				withAttribute: (PluggableTextAttribute
						evalBlock: [self userInterface
										sendMailTo: self owner email
										regardingPackageRelease: self lastRelease])
				do: [s nextPutAll: self owner nameAndEmail];	
				 cr].

	self maintainers isEmpty ifFalse: [
		s withAttribute: TextEmphasis bold do: [s nextPutAll: 'Co-maintainers:']; tab.
		self maintainers do: [:com |
			com = self maintainers first ifFalse: [s nextPutAll: ', '].
			s
				withAttribute:
					(PluggableTextAttribute
						evalBlock: [self userInterface
									sendMailTo: com email
									regardingPackageRelease: self lastRelease])
				do: [s nextPutAll: com nameAndEmail]].
				s cr].

	description isEmptyOrNil
		ifFalse: [s cr.
			s
				withAttribute: TextEmphasis bold
				do: [s nextPutAll: 'Description:'].
			s cr.
			s
				withAttribute: (TextIndent tabs: 1)
				do: [s next: (description findLast: [ :c | c isSeparator not ]) putAll: description].
			s cr ].

	self describeCategoriesOn: s indent: 1.

	s cr.
	publishedRelease := self lastPublishedRelease.
	self
		describe: (self publishedVersion ifNil: ['<not published>'])
		withBoldLabel: 'Published version: '
		on: s.
	self isPublished ifTrue: [
		s
			withAttribute: TextEmphasis bold do: [ s nextPutAll: 'Created: ' ];
			print: publishedRelease created;
			cr.
			self note isEmptyOrNil
				ifFalse: [s
					withAttribute: TextEmphasis bold
					do: [s nextPutAll: 'Release note:'].
			s cr.
			s
				withAttribute: (TextIndent tabs: 1)
				do: [s nextPutAll: publishedRelease note].
			s cr ]].

	url isEmptyOrNil
		ifFalse: [s cr;
				withAttribute: TextEmphasis bold
				do: [s nextPutAll: 'Homepage:'];
				 tab;
				withAttribute: (TextURL new url: url)
				do: [s nextPutAll: url];
				 cr].

	^ s contents
testAddressesIn

	| testString correctAnswer |

	testString _ 'joe@lama.com, joe2@lama.com joe3@lama.com joe4 , Not an Address <joe5@address>, joe.(annoying (nested) comment)literal@[1.2.3.4], "an annoying" group : joe1@groupie, joe2@groupie, "Joey" joe3@groupy, "joe6"."joe8"@group.com;,  Lex''s email account <lex>'.

correctAnswer _ #('joe@lama.com' 'joe2@lama.com' 'joe3@lama.com' 'joe4' 'joe5@address' 'joe.literal@[1.2.3.4]' 'joe1@groupie' 'joe2@groupie' '"Joey"' 'joe3@groupy' '"joe6"."joe8"@group.com' 'lex') asOrderedCollection.

	self should:	[(MailAddressParser addressesIn: testString) =  correctAnswer].
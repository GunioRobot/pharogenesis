selfTest

	| msgText msg |

	msgText _ 
'Date: Tue, 20 Feb 2001 13:52:53 +0300
From: mdr@scn.rg (Me Ru)
Subject: RE: Windows 2000 on your laptop
To: "Greg Y" <to1@mail.com>
cc: cc1@scn.org, cc1also@test.org
To: to2@no.scn.org, to2also@op.org
cc: cc2@scn.org

Hmmm... Good.  I will try to swap my German copy for something in
English, and then do the deed.  Oh, and expand my RAM to 128 first.

Mike
'.

	msg _ self new from: msgText.

	[msg text = msgText] assert.
	[msg subject = 'RE: Windows 2000 on your laptop'] assert.
	[msg from = 'mdr@scn.rg (Me Ru)'] assert.
	[msg date = '2/20/01'] assert.
	[msg time = 667133573] assert.
	"[msg name] assert."
	[msg to = '"Greg Y" <to1@mail.com>, to2@no.scn.org, to2also@op.org'] assert.
	[msg cc = 'cc1@scn.org, cc1also@test.org, cc2@scn.org'] assert.

	"MailMessage selfTest"

show6a

    " B3DDemoSpheres new show6a"

     | view |

  self createScene6a.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene6a;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view beRotating; openInSystemWindow.
show8

    " B3DDemoSolids new show8"

     | view |

  self createScene8.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene8;
     scene: scene.
  view clearColor: (Color gray: 0.8).
  view rotateX: 25.4.
  view openInSystemWindow.
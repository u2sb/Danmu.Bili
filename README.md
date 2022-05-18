这是一个解析 B 站弹幕，并转换为其他播放器弹幕格式的项目。

## API

约定:

- `id` bvid 或 aid
- `p` 分 P，默认为 1
- `format` 数据格式，json 或 xml

API:

- 原始弹幕 `/api/danmu/bilibili/v1/{id}/{p:int?}` 或 `/api/danmu/bilibili/v1/?id={id}&p={p}`
- 原始弹幕 原始数据 `/api/danmu/bilibili/v1/raw/{id}/{p:int?}` 或 `/api/danmu/bilibili/v1/raw/?id={id}&p={p}`
- Dplayer `/api/danmu/dplayer/v3/{id}/{p:int?}` 或 `/api/danmu/dplayer/v3/?id={id}&p={p}`
- ArtPlayer `/api/danmu/artplayer/v1/{id}/{p:int}.{format?}` 或 `/api/danmu/artplayer/v1.{format?}?id={id}&p={p}`

本项目仅用于学习研究，参考项目:

- [Bili.Uwp](https://github.com/Richasy/Bili.Uwp)
- [bilibili-API-collect](https://github.com/SocialSisterYi/bilibili-API-collect)
